using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostingAPI.Data;
using PostingAPI.Models;
using PostingAPI.Models.Dto;

namespace PostingAPI.Controllers
{
    [Route("api/Posting")]
    [ApiController]
    public class PostingAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
        public PostingAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }
        [HttpGet]
        // public async ResponseDto Get()
        public ResponseDto? Get()
        {
            IEnumerable<Posting> objList;
            try
            {
                //IEnumerable<Posting> objList = _db.Posting.ToList();
                //_response.Result = _mapper.Map<IEnumerable<PostingDto>>(objList);
                // var cusomter = await _db.Posting
                //    .Include(_ => _.PostingDetails).ToListAsync();
                objList= _db.Posting.Include(p=>p.PostDetails).ToList();
                _response.Result = _mapper.Map<IEnumerable<Posting>>(objList);
               // return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
           // return Ok(Response);
        }
        [HttpPost]
     //   [Authorize(Roles = "ADMIN")]
        public ResponseDto Post(PostingDto PostingDto)
        {
            try
            {
                Posting posting = _mapper.Map<Posting>(PostingDto);
                _db.Posting.Add(posting);
                _db.SaveChanges();
                _response.Result = _mapper.Map<PostingDto>(posting);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

    }
   
}
