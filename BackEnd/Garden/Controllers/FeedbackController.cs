/*
 * @Author: Jialin Lu
 * @GitHub: https://github.com/tju2050633
 * @Date: 2023-09-05 15:55:16
 * @FilePath: /SharingGardenProject/BackEnd/Garden/Controllers/FeedbackController.cs
 * @Description: 
 * 
 * Copyright (c) 2023 by 1640889387@qq.com, All Rights Reserved. 
 */
using Garden.BLL.Interfaces;
using Garden.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Garden.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackBLL _feedbackBLL;

        public FeedbackController(IFeedbackBLL feedbackBLL)
        {
            _feedbackBLL = feedbackBLL;
        }

        [HttpGet("/feedback/get")]
        public IEnumerable<Feedback> GetSingleFeedback()
        {
            return _feedbackBLL.GetSingleFeedback();
        }

        [HttpPost("/feedback/post")]
        public IActionResult PostFeedback([FromForm] string feedbackJson)
        {
            Console.WriteLine("feedbackJson : " + feedbackJson);
            _feedbackBLL.InsertFeedback(JsonConvert.DeserializeObject<FeedbackModel>(feedbackJson));

            return Ok();
        }
    }
}
