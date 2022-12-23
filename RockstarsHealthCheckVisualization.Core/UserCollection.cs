namespace RockstarsHealthCheckVisualization.Core;

public class UserCollection
{
    private List<User> userList = new List<User>();
	private IRepository repository;

	public List<User> UserList { get { return userList; } }

	public UserCollection(IRepository repository)
	{
		this.repository = repository;

		userList.AddRange(repository.GetUserList());
	}


}
