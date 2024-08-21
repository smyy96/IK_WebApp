﻿using BESMIK.BLL.Managers.Concrete;
using BESMIK.Common;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.Advance;
using BESMIK.ViewModel.AppUser;
using BESMIK.ViewModel.Spending;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BESMIK.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpendingController : Controller
    {
        private readonly SpendingManager _spendingService;

        //private readonly BLL.Managers.Concrete.Spending _spending; //buna gerek yok sc

        public SpendingController(SpendingManager spendingService)

        {
            _spendingService = spendingService;
        }


        [HttpGet("SpendingList")]
        public ActionResult<IEnumerable<SpendingViewModel>> GetList()
        {
            var spendings = _spendingService.GetAll();
            return Ok(spendings);

        }

        [HttpPost("SpendingAdd")]
        public IActionResult Post([FromBody] SpendingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _spendingService.Add(model);
            return Ok(model);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var spending = _spendingService.Get(id);
            if (spending == null)
            {
                return NotFound();
            }

            return Ok(spending);
        }


        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var existingSpending = _spendingService.Get(id);
            if (existingSpending == null)
            {
                return NotFound();
            }

            if (existingSpending.SpendingStatus != SpendingStatus.OnayBekliyor)
            {
                return Forbid("Silme işlemi sadece 'OnayBekliyor' durumundaki harcamalar için yapılabilir.");
            }

            _spendingService.Delete(id);
            return NoContent();
        }

        //[HttpPut("Update/{id}")]
        //public IActionResult Update(int id, [FromBody] SpendingViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var existingSpending = _spendingService.Get(id);
        //    if (existingSpending == null)
        //    {
        //        return NotFound();
        //    }

        //    // Güncellenmesi gereken alanlar
        //    if (model.SpendingType != null)
        //        existingSpending.SpendingType = model.SpendingType;

        //    if (model.Sum != null)
        //        existingSpending.Sum = model.Sum;

        //    if (model.SpendingCurrency != null)
        //        existingSpending.SpendingCurrency = model.SpendingCurrency;

        //    if (model.SpendingFile != null)
        //        existingSpending.SpendingFile = model.SpendingFile;

        //    _spendingService.Update(existingSpending);

        //    return NoContent();
        //}



        [HttpGet("GetSpending/{id}")]
        public IActionResult GetSpending(int id)
        {
            var spending = _spendingService.Get(id);

            if (spending == null)
                return NotFound("Avans bulunamadı.");

            if (spending.SpendingStatus!= SpendingStatus.OnayBekliyor)
            {
                return StatusCode(403, "Avans düzenlenemez çünkü Avans talebi cevaplanmış/onay bekliyor durumunda değil.");
            }

            return Ok(spending);
        }

        [HttpPut("EditSpending/{id}")]
        public IActionResult EditSpending(int id, [FromBody] SpendingViewModel updatedSpending)
        {
            var mevcutHarcama = _spendingService.Get(id);

            if (mevcutHarcama == null)
                return NotFound();

            mevcutHarcama.SpendingType = updatedSpending.SpendingType;
            mevcutHarcama.Sum = updatedSpending.Sum;
            mevcutHarcama.SpendingCurrency = updatedSpending.SpendingCurrency;
            mevcutHarcama.SpendingFile = updatedSpending.SpendingFile;
            mevcutHarcama.SpendingStatus = updatedSpending.SpendingStatus;
            mevcutHarcama.SpendingResponseDate=updatedSpending.SpendingResponseDate;
            mevcutHarcama.SpendingRequestDate=updatedSpending.SpendingRequestDate;

            _spendingService.Update(mevcutHarcama);

            return Ok("harcama başarıyla güncellendi.");
        }

    }
}
