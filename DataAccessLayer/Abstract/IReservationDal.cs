using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDal : IGenericDal<Reservation>
    {
        List<Reservation> GetListWithReservationByWaitApproval(int id); //Onay bekleyen 

        List<Reservation> GetListWithReservationByAccepted(int id);  // Kabul edilen 
        List<Reservation> GetListWithReservationByPrevious(int id); //geçmiş rezervasyonlar
    }
}
