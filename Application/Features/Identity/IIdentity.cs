using PetClinic.Application.Common;
using PetClinic.Application.Features.Identity.Commands;
using PetClinic.Application.Features.Identity.Commands.ChangePassword;
using PetClinic.Application.Features.Identity.Commands.LoginUser;
using System.Threading.Tasks;

namespace Application.Features.Identity
{
    public interface IIdentity
    {
        Task<Result<IUser>> Register(UserInputModel userInput);

        Task<Result<LoginSuccessModel>> Login(UserInputModel userInput);

        Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput);
    }
}
