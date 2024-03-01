using IMAMComputerAPI.Data;
using IMAMComputerAPI.Dto;
using IMAMComputerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;

namespace IMAMComputerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Context _dbContext;
        public UsersController(Context dbContext)
        {
            _dbContext = dbContext;  
        }

        [HttpGet("GetAllUsersAsync")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _dbContext.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("GetByIdUserAsync")]
        public async Task<IActionResult> GetByIdUser(Guid id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user ==null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("AddUserAsync")]
        public async Task<IActionResult> Register([FromForm]AddUserDto addUserDto)
        {
            var newUser = new User()
            {
                UserID = Guid.NewGuid(),
                UserFirstName = addUserDto.UserFirstName,
                UserLastName = addUserDto.UserLastName,
                UserEmail = addUserDto.UserEmail,
                UserPassword = addUserDto.UserPassword,
                UserCity = addUserDto.UserCity,
                UserDistrict = addUserDto.UserDistrict,
                UserAddressDetails = addUserDto.UserAddressDetails
            };

            //string hashedPassword = addUserDto.UserPassword + "sadasd";

            await _dbContext.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();
            return Ok(newUser);
        }



        public async Task AddBasket(User user, Product product) //tokendan aldın
        {
            var foundUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserID == user.UserID);
            if (foundUser == null) throw new Exception("Yetki yok");
            foundUser.Baskets.Add(new Basket()
            {
                Product = product
            });
            await _dbContext.SaveChangesAsync();


            //login
            var isUserExists = await _dbContext.Users.AnyAsync(u => u.UserEmail == user.UserEmail && u.UserPassword == user.UserPassword);
            "saljdmklsamdlkasm"

        }

        //Services katmanı

        //Repositoryler

        [HttpPut("UpdateUserAsync")]
        public async Task<IActionResult> UpdateUser(Guid id,UpdateUserDto updateUserDto)
        {
            var user =await _dbContext.Users.FindAsync(id);
            if (user!=null)
            {
                user.UserFirstName = updateUserDto.UserFirstName;
                user.UserLastName = updateUserDto.UserLastName;
                user.UserEmail = updateUserDto.UserEmail;
                user.UserPassword = updateUserDto.UserPassword;
                user.UserCity = updateUserDto.UserCity;
                user.UserDistrict = updateUserDto.UserDistrict;
                user.UserAddressDetails = updateUserDto.UserAddressDetails;

                await _dbContext.SaveChangesAsync();
                return Ok(user);
            }

            return NotFound();
        }

        [HttpDelete("DeleteUserAsync")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user != null)
            {
                _dbContext.Remove(user);
                await _dbContext.SaveChangesAsync();
                return Ok(user);
            }

            return NotFound();
        }
    }
}
