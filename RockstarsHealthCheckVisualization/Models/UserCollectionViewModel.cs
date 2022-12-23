namespace RockstarsHealthCheckVisualization.Models;

public class UserCollectionViewModel
{
    public List<UserViewModel> UserList { get; set; }

	public UserCollectionViewModel()
	{
		UserList = new List<UserViewModel>();
	}
}
