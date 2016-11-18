using System;
using System.Collections.Generic;
using System.Linq;
using SecretSanta.Core;
using SecretSanta.Core.Model;

namespace SecretSanta.Ui.Console
{
    internal static class Sample
    {
        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                for (var i = 0; i <= 100; i++)
                {
                    var grps = new List<Group>
                    {
                        new Group(new List<User>()
                        {
                            new User("A1","a1@mail.com"),
                            new User("A2","a2@mail.com"),
                            new User("A3","a3@mail.com")	
                        }),
                        new Group(new List<User>()
                        {
                            new User("B1","b1@mail.com"),
                            new User("B2","b2@mail.com")
                        }),
                        new Group(new List<User>()
                        {
                            new User("C1","c1@mail.com"),
                            new User("C2","c2@mail.com"),
	        					
                        }),
                        new Group(new List<User>()
                        {
                            new User("D1","d1@mail.com"),
                            new User("D2","d2@mail.com")
                        }),
                        new Group(new List<User>()
                        {
                            new User("E1","e1@mail.com")
                        })
                    };
            	
                    grps = new List<Group>(grps.OrderBy(u=> Guid.NewGuid()).ToList());
                
                    var paires = Lottery.Run(grps);

                    MailSender.SendMails(paires,"");
                
                    System.Console.WriteLine("/------/");
             
                   
                }
                System.Console.ReadLine();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                System.Console.ReadLine();
            }
        }
    }
}
