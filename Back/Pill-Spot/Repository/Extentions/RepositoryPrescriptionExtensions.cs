using Entities.Models;
using Repository.Utility;
using Shared.RequestFeatures;
using System.Linq.Dynamic.Core;

public static class RepositoryPrescriptionExtensions
{
    //public static IQueryable<Prescription> Filter(this IQueryable<Prescription> prescriptions, PrescriptionParameters parameters)
    //{
        
    //    if (parameters.Status.HasValue)
    //        prescriptions = prescriptions.Where(p => p.Status == parameters.Status.Value);
        
    //    if (parameters.MinIssueDate.HasValue)
    //        prescriptions = prescriptions.Where(p => p.IssueDate >= parameters.MinIssueDate.Value);
        
    //    if (parameters.MaxIssueDate.HasValue)
    //        prescriptions = prescriptions.Where(p => p.IssueDate <= parameters.MaxIssueDate.Value);

    //    return prescriptions;
    //}

    public static IQueryable<Prescription> Search(this IQueryable<Prescription> prescriptions, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return prescriptions;

        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return prescriptions.Where(p => p.UserId.ToLower().Contains(lowerCaseTerm));
    }

    public static IQueryable<Prescription> Sort(this IQueryable<Prescription> prescriptions, string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return prescriptions.OrderByDescending(p => p.IssueDate);

        var orderQuery = OrderQueryBuilder.CreateOrderQuery<Prescription>(orderByQueryString);
        if (string.IsNullOrWhiteSpace(orderQuery))
            return prescriptions.OrderByDescending(p => p.IssueDate);

        return prescriptions.OrderBy(orderQuery);
    }
}