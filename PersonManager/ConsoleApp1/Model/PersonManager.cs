using ConsoleApp1.DAL;
using ConsoleApp1.Events;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    public class PersonManager
    {
        private IRepo repo = RepoFactory.GetRepo();

        public event OnExceptionDelegate OnException;//So we can invoke them when needed
        public event OnLoadedDelegate OnLoaded;

        private IDictionary<string, Person> personsDictionary;

        //Lazy pull
        public IDictionary<string,Person> GetPersonsDitcionary()
        {
            if (personsDictionary==null)
            {
                LoadDictionary();
            }

            return new Dictionary<string, Person>(personsDictionary);//Always return copy
        }

        private void LoadDictionary()
        {
            personsDictionary = new Dictionary<string, Person>();
            IList<Person> persons;

            //Loading pearsons can throw a lot of exception, must be in trycatc
            try
            {
                persons=repo.LoadPerons();
            }
            catch (Exception e)
            {
                OnException?.Invoke(this, new OnExceptionEventArgs { Exception = e });
                return;
            }

            //Loading into Dictionary

            foreach (var p in persons)
            {
                try
                {
                    if (p.HasValidOIB())
                    {
                        IList<string> missingData = new List<string>();

                        //If user doesn't have some prop, but that in missing data list
                        if (string.IsNullOrEmpty(p.Name))
                        {
                            missingData.Add(nameof(p.Name));
                        }
                        if (string.IsNullOrEmpty(p.Surname))
                        {
                            missingData.Add(nameof(p.Surname));
                        }
                        if (string.IsNullOrEmpty(p.Phone))
                        {
                            missingData.Add(nameof(p.Phone));
                        }
                        if (string.IsNullOrEmpty(p.Email))
                        {
                            missingData.Add(nameof(p.Email));
                        }

                        personsDictionary.Add(p.OIB, p);//Key-OIB,Value-Person
                        //If persons is loaded, call event
                        OnLoaded?.Invoke(this, new OnLoadedEventArgs { LoadedPerson = p, MissingData = missingData });

                    }
                    else
                    {
                        //Exceptions.-> to put exception that is being created in new folder
                        throw new Exceptions.InvalidOIBException($"{p.OIB} is not valid!");
                    }
                }
                //Catch InvalidOIBException
                catch (InvalidOIBException e)

                {
                    //if there is exception, call OnException event
                    OnException?.Invoke(this, new OnExceptionEventArgs { Exception = e });
                }
            }

        }

        //SavePersons can throw a lot of exception-> must be in trycatch
        public void SavePersons(IList<Person> persons)
        {
            try
            {
                repo.SavePersons(persons);
            }
            catch (Exception e)
            {
                OnException?.Invoke(this, new OnExceptionEventArgs { Exception = e });
            }
        }
    }
}
