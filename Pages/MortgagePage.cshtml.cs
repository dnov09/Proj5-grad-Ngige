using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Proj5_grad_Ngige.Pages
{
    public class MortgagePageModel : PageModel

    {

        public string ReturnValue { get; set; } = "";

        [BindProperty]
        [Required]
        public double? DurationInput { get; set; } = 0;



        [BindProperty]
        [Required]
        public double? LoanInput { get; set; } = 0;


        [BindProperty]
        [Required]
        public double? InterestInput { get; set; } = 0;



        public async Task OnPost()

        {

            if (ModelState.IsValid)

            {

                HttpClient httpClient = new();

                var Result = await httpClient.GetAsync($"https://mortgagecalcfunction20220406070759.azurewebsites.net/api/MortgageAzureCalc?code=U0rlxlf2tDsOayYSy/6J52tEL83O7lG8Hat7AXYytwJEAPO45DDtaQ==&loan={LoanInput.Value}&duration={DurationInput.Value}&interest={InterestInput.Value}");

                string ResultString = await Result.Content.ReadAsStringAsync();

                double.TryParse(ResultString, out double val);



                ReturnValue = $"The Monthly payment is ${val} for a loan of ${LoanInput.Value} for {DurationInput.Value} years and an interest rate of {InterestInput.Value}%";

            }

            else



            {

                ReturnValue = "Please check your input and computer again";

            }



        }



    }
}
