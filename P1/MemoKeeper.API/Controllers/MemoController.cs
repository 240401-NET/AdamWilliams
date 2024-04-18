using MemoKeeper.Data;
using MemoKeeper.Models;
using MemoKeeper.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace MemoKeeper.API.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class MemoController : ControllerBase
    {
        private readonly IMemoService _memoService;
        
        public MemoController(IMemoService memoService)
        {
            _memoService = memoService;
        }

        [HttpGet ("/allmemos")]
        public IEnumerable<Memo> GetAllMemos()
        {
             return _memoService.GetAllMemos();
        }

        [HttpPost ("/addmemo")]
        public Memo AddMemo([FromBody] Memo memo)
        {
            return _memoService.CreateNewMemo(memo);
        }

        [HttpPost ("/deletememo")]
        public void DeleteMemo([FromQuery] int id)
        {
            _memoService.DeleteMemo(id); 
        }

        [HttpPost ("/editmemo")] 
        public Memo EditMemo([FromQuery]int id, Memo editedMemo)
        {
            return _memoService.EditMemo(id, editedMemo);
        }

        [HttpPost ("/deleteallmemos")]
        public void DeleteAllMemos()
        {
            _memoService.DeleteAllMemos();
        }
    }

