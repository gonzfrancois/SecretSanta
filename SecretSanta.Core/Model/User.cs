using System;

namespace SecretSanta.Core.Model
{
	public class User : IEquatable<User>
	{
	    private Guid Id { get; }
        public string Name { get; }
        public string MailAddress { get; }
        private Group Group { get; set; }

	    public User(string name, string mailAddress)
	    {
	        Id = Guid.NewGuid();
	        Name = name;
	        MailAddress = mailAddress;
	    }
	    
	    public User(string name, string mailAddress, Group group) : this(name, mailAddress)
	    {
	    	JoinGroup(group);
	    }
	
	    public void JoinGroup(Group group)
	    {
	        group.AddUser(this);
	        Group = group;
	    }
	
	    public void QuitGroup()
	    {
	        Group.RemoveUser(this);
	        Group = null;
	    }
			
		public bool Equals(User other)
		{
			return other!=null && Id == other.Id;
		}
	}
}
