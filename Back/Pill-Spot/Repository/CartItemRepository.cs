using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Repository.Extentions;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class CartItemRepository : RepositoryBase<CartItem>, ICartItemRepository
    {
        public CartItemRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<PagedList<CartItem>> GetCartItemsByCartIdAsync(
            Guid cartId,
            CartItemRequestParameters parameters,
            bool trackChanges)
        {
            var items = await FindByCondition(i => i.CartId.Equals(cartId), trackChanges)
                .Include(i => i.PharmacyProduct)
                    .ThenInclude(pp => pp.Product)
                        .ThenInclude(p => p.SubCategory)
                            .ThenInclude(sc => sc.Category)
                .Include(i => i.PharmacyProduct)
                    .ThenInclude(pp => pp.Pharmacy)
                        .ThenInclude(p => p.Location)
                .ApplyCartItemFilters(parameters)
                .OrderBy(i => i.AddedAt)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            var count = await FindByCondition(i => i.CartId.Equals(cartId), trackChanges)
                .ApplyCartItemFilters(parameters)
                .CountAsync();

            return new PagedList<CartItem>(items, count, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<IEnumerable<CartItem>> GetItemsByPharmacyAsync(
            Guid cartId,
            Guid pharmacyId,
            bool trackChanges) =>
            await FindByCondition(i => i.CartId.Equals(cartId) && i.PharmacyId.Equals(pharmacyId), trackChanges)
                .Include(i => i.PharmacyProduct)
                    .ThenInclude(pp => pp.Product)
                .ToListAsync();

        public async Task<IEnumerable<CartItem>> GetCartItemsWithDetailsAsync(
            Guid cartId,
            bool trackChanges) =>
            await FindByCondition(i => i.CartId.Equals(cartId), trackChanges)
                .Include(i => i.PharmacyProduct)
                    .ThenInclude(pp => pp.Product)
                .Include(i => i.PharmacyProduct)
                    .ThenInclude(pp => pp.Pharmacy)
                .Include(i => i.RespondedByUser)
                .ToListAsync();

        public async Task<CartItem> GetCartItemByIdsAsync(
            Guid cartId,
            Guid productId,
            Guid pharmacyId,
            bool trackChanges) =>
            await FindByCondition(i => i.CartId.Equals(cartId) && i.ProductId.Equals(productId) && i.PharmacyId.Equals(pharmacyId), trackChanges)
                .Include(i => i.PharmacyProduct)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<CartItem>> GetPendingApprovalItemsAsync(Guid cartId, bool trackChanges) =>
            await FindByCondition(i => i.CartId.Equals(cartId) && i.PharmacyApproved == CartItemApprovalStatus.Pending, trackChanges)
                .Include(i => i.PharmacyProduct)
                    .ThenInclude(pp => pp.Product)
                .ToListAsync();

        public async Task<int> GetItemCountByCartAsync(Guid cartId, bool trackChanges) =>
            await FindByCondition(i => i.CartId.Equals(cartId), trackChanges)
                .CountAsync();

        public async Task UpdateItemApprovalsAsync(
            Guid cartId,
            Dictionary<Guid, (CartItemApprovalStatus? Status, string? Reason, RejectionType? Type, string? RespondedByUserId)> approvals,
            bool trackChanges)
        {
            var items = await FindByCondition(i => i.CartId.Equals(cartId) && approvals.ContainsKey(i.CartItemId), trackChanges)
                .ToListAsync();

            foreach (var item in items)
            {
                var approval = approvals[item.CartItemId];
                item.PharmacyApproved = approval.Status;
                item.RejectionReason = approval.Reason;
                item.RejectionType = approval.Type;
                item.RespondedByUserId = approval.RespondedByUserId;
                item.PharmacyRespondedAt = approval.Status != null ? DateTime.UtcNow : null;
            }
        }

        public async Task DeleteItemsByCartAsync(Guid cartId, bool trackChanges) =>
            await FindByCondition(i => i.CartId.Equals(cartId), trackChanges)
                .ExecuteUpdateAsync(setters => setters.SetProperty(i => i.IsDeleted, true));

        public void CreateItem(CartItem item) => Create(item);

        public void UpdateItem(CartItem item) => Update(item);

        public void DeleteItem(CartItem item) => item.IsDeleted = true;

        public async Task<CartItem> GetByIdAsync(Guid cartItemId)
        {
            return await FindByCondition(i => i.CartItemId == cartItemId && !i.IsDeleted, false)
                .Include(i => i.PharmacyProduct)
                    .ThenInclude(pp => pp.Product)
                .SingleOrDefaultAsync();
        }
    }
}