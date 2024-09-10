using lockerSystem.Domain;
using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SQLitePCL;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace lockerSystem.Controllers
{
    public class OrderController : Controller

    {
        private readonly BookingDomain _bookingDomain;
        // private readonly OrderDomain _orderDomain;
        public OrderController(BookingDomain bookingDomain)
        {
            _bookingDomain = bookingDomain;

        }

        public async Task<IActionResult> Index(string seaechString)
        {
            //var bookings = await _bookingDomain.GetAllbooking();
            //return View(bookings);
            var bookings = await _bookingDomain.GetAllbooking();
            if (!String.IsNullOrEmpty(seaechString))
            {
                bookings = bookings.Where(n => n.fullName.Contains(seaechString)).ToList();

            }
            return View(bookings);
        }
        public async Task<IActionResult> details(Guid id)
        {
            var bookings = await _bookingDomain.GetBookingByGuid(id);
            return View(bookings);
        }
      //
        [HttpGet]
        public async Task<IActionResult> Accept(Guid id)
        {
            var bookingViewModel = await _bookingDomain.GetBookingByGuid(id);

            if (bookingViewModel == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                bookingViewModel.BookingStateId = 2;
                if (bookingViewModel.BookingStateId == 2) {

                    bookingViewModel.Locker.LockerStateId= 2;

                }
          
                string check = await _bookingDomain.UpdateBooking(bookingViewModel);

                if (check == "1")
                {
                    ViewData["Successful"] = "تم تحديث حالة الحجز";
                }
                else
                {
                    ViewData["Failed"] = check;
                }
            }

            return View();
        }
        public async Task<IActionResult> Reject(Guid id)
        {
            var bookingViewModel = await _bookingDomain.GetBookingByGuid(id);

            if (bookingViewModel == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                if (bookingViewModel.BookingStateId == 2)
                {

                    bookingViewModel.Locker.LockerStateId = 3;

                }

                bookingViewModel.BookingStateId = 3;

                string check = await _bookingDomain.UpdateBooking(bookingViewModel);

                if (check == "1")
                {
                    ViewData["Successful"] = "تم تحديث حالة الحجز";
                }
                else
                {
                    ViewData["Failed"] = check;
                }
            }

            return View();
        }

       
        //public async Task<IActionResult> Reject(Guid guid)
        //{
        //    var booking = await _bookingDomain.GetBookingByGuid(guid);


        //    booking.BookingStateId = 3; // Set the booking state to "Rejected"
        //    await _bookingDomain.UpdateBooking(booking);
        //    return View();

        //}


    }
}
