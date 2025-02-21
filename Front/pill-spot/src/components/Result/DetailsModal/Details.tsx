
const Details = () => {
  const openModal = () => {
    const modal = document.getElementById("my_modal_2") as HTMLDialogElement;
    modal?.showModal();
  };

  return (
    <div>
      <button className="btn text-[#02457a]" onClick={openModal}>
        Details
      </button>
      <dialog id="my_modal_2" className="modal">
        <div className="modal-box">
          <h3 className="font-bold text-lg">Hello!</h3>
          <p className="py-4">Pharmacy Details will appear here when its API is available </p>
        </div>
        <form method="dialog" className="modal-backdrop">
          <button type="submit">close</button>
        </form>
      </dialog>
    </div>
  );
};

export default Details;
