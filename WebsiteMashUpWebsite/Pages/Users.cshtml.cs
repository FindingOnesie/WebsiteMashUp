using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebsiteModels.MongoModels;
using WebsiteModels.MongoRepos;

namespace WebsiteMashUpWebsite.Pages
{
    public class UsersModel : PageModel
    {
        private readonly UserRepository _userRepository;

        public List<User> Users { get; private set; }

        public UsersModel(UserRepository userRepository) {
            _userRepository = userRepository;
        }

        public async Task OnGetAsync() {
            Users = await _userRepository.GetUsersAsync();
        }
    }
}
