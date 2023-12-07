using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class TestController : ControllerBase
{
    [HttpGet("authorized")]
    public ActionResult GetAsAuthorized()
    {
        return Ok("This was accepted as authorized");
    }
    
    
  
    // manual checking
    [HttpGet("manualcheck")]
    public ActionResult GetWithManualCheck()
    {
        Claim? claim = User.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.Role));
        if (claim == null)
        {
            return StatusCode(403, "You have no role");
        }

        string userRole = claim.Value;

        if (userRole.Equals("CafeOwner"))
        {
            // Actions for CafeOwner role
            return Ok("You are a CafeOwner, you may proceed");
        }
        else if (userRole.Equals("Entertainer"))
        {
            // Actions for Entertainer role
            return Ok("You are a Entertainer, you may proceed");
        }
        else if (userRole.Equals("User"))
        {
            // Actions for User role
            return Ok("You are an User, you may proceed");
        }
        else
        {
            return StatusCode(403, "Access denied");
        }
    }
    
    // policy MustBeCafeOwner
    [HttpGet("must-be-cafe-owner"), Authorize("MustBeCafeOwner")]
    public ActionResult GetAsCafeOwner()
    {
        return Ok("This was accepted as role is CafeOwner");
    }
    
  
    
   /*   

    // policy MustBeEntertainer
    [HttpGet("must-be-entertainer"), Authorize("MustBeEntertainer")]
    public ActionResult GetAsEntertainer()
    {
        return Ok("This was accepted as role is Entertainer");
    }

    // policy MustBeUser
    [HttpGet("must-be-user"), Authorize("MustBeUser")]
    public ActionResult GetAsUser()
    {
        return Ok("This was accepted as role is User");
    }
*/
    
}