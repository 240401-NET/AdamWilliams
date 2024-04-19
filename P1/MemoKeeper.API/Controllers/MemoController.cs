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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<Memo> GetAllMemos()
        {
             return _memoService.GetAllMemos();
        }

        [HttpGet ("/search{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Memo GetMemoById(int id)
        {
            return _memoService.GetMemoById(id);
        }

        [HttpGet ("/search/{date}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Memo>> GetMemoByDate(string date)
        {
            try
            {
                List<Memo> memos = _memoService.GetMemoByDate(date);
                if(!memos.Any())
                {
                    return NoContent();
                }
                return Ok(memos);
            }
            catch (FormatException e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost ("/addmemo")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public Memo AddMemo([FromBody]Memo memo)
        {
            return _memoService.CreateNewMemo(memo);
        }

        [HttpPost ("/editmemo")]
        [ProducesResponseType(StatusCodes.Status200OK)] 
        public Memo EditMemo([FromQuery]int id, [FromBody]Memo editedMemo)
        {
            return _memoService.EditMemo(id, editedMemo);
        }

        [HttpDelete ("/deletememo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public void DeleteMemo([FromQuery]int id)
        {
            _memoService.DeleteMemo(id); 
        }

        [HttpDelete ("/deleteallmemos")]
        public void DeleteAllMemos()
        {
            _memoService.DeleteAllMemos();
        }
    }

