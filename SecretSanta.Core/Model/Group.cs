using System;
using System.Collections.Generic;
using System.Linq;

namespace SecretSanta.Core.Model
{
	public class Group : IEquatable<Group>
	{
	    private Guid Id { get; }
        public List<User> Users { get; private set; }

	    private Group()
	    {
	        Id = Guid.NewGuid();
	        Users = new List<User>();
	    }
	    
	    public Group(IEnumerable<User> users) : this()
	    {
	    	foreach (var user in users)
	    		user.JoinGroup(this);
	    }
	
	    public void AddUser(User user)
	    {
	        Users.Add(user);
	        ShuffleUsers();
	    }
	
	    public void RemoveUser(User user)
	    {
	        Users.Remove(user);
	        ShuffleUsers();
	    }
	    
	    private void ShuffleUsers()
	    {
	    	Users = new List<User>(Users.OrderBy(u=> Guid.NewGuid()).ToList());
	    }
		
		public bool Equals(Group other)
		{
			return other!=null && Id == other.Id;
		}
	}
}
