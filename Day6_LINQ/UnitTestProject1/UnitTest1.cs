using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private List<User> userListFirst = new List<User>
        {
            new User
            {
                Age = 21,
                Gender = Gender.Man,
                Name = "User1",
                Salary = 21000
            },

            new User
            {
                Age = 30,
                Gender = Gender.Female,
                Name = "Liza",
                Salary = 30000
            },

            new User
            {
                Age = 18,
                Gender = Gender.Man,
                Name = "Max",
                Salary = 19000
            },
            new User
            {
                Age = 32,
                Gender = Gender.Female,
                Name = "Ann",
                Salary = 36200
            },
            new User
            {
                Age = 45,
                Gender = Gender.Man,
                Name = "Alex",
                Salary = 54000
            }
        };

        private List<User> userListSecond = new List<User>
        {
            new User
            {
                Age = 23,
                Gender = Gender.Man,
                Name = "Max",
                Salary = 24000
            },

            new User
            {
                Age = 30,
                Gender = Gender.Female,
                Name = "Liza",
                Salary = 30000
            },

            new User
            {
                Age = 23,
                Gender = Gender.Man,
                Name = "Max",
                Salary = 24000
            },
            new User
            {
                Age = 32,
                Gender = Gender.Female,
                Name = "Kate",
                Salary = 36200
            },
            new User
            {
                Age = 45,
                Gender = Gender.Man,
                Name = "Alex",
                Salary = 54000
            },
            new User
            {
                Age = 28,
                Gender = Gender.Female,
                Name = "Kate",
                Salary = 21000
            }
        };

        [TestMethod]
        public void SortByName()
        {
            var actualDataFirstList = new List<User>();
            var expectedData = userListFirst[4];

            //ToDo Add code first list
            List<User> result = userListFirst.Select(e => e).ToList();
            result.Sort((x, y) => x.Name.CompareTo(y.Name));
            actualDataFirstList.AddRange(result);
            Assert.IsTrue(actualDataFirstList[0].Equals(expectedData));
        }

        [TestMethod]
        public void SortByNameDescending()
        {
            var actualDataSecondList = new List<User>();
            var expectedData = userListFirst[0];

            //ToDo Add code first list
            List<User> result = userListFirst.Select(e => e).ToList();
            result.Sort((x, y) => y.Name.CompareTo(x.Name));
            actualDataSecondList.AddRange(result);
            Assert.IsTrue(actualDataSecondList[0].Equals(expectedData));
            
        }

        [TestMethod]
        public void SortByNameAndAge()
        {
            var actualDataSecondList = new List<User>();
            var expectedData = userListSecond[4];

            //ToDo Add code second list
            List<User> result = userListSecond.Select(e => e).ToList();
            result.Sort((x, y) => { if (x.Name == y.Name) return x.Age.CompareTo(y.Age); else return x.Name.CompareTo(y.Name); });
            actualDataSecondList.AddRange(result);
            Assert.IsTrue(actualDataSecondList[0].Equals(expectedData));
        }

        [TestMethod]
        public void RemovesDuplicate()
        {
            var actualDataSecondList = new List<User>();
            var expectedData = new List<User> {userListSecond[0], userListSecond[1], userListSecond[3], userListSecond[4],userListSecond[5]};

            var result = userListSecond.Distinct();
            actualDataSecondList.AddRange(result);
            CollectionAssert.AreEqual(expectedData, actualDataSecondList);
        }

        [TestMethod]
        public void ReturnsDifferenceFromFirstList()
        {
            var actualData = new List<User>();
            var expectedData = new List<User> { userListFirst[0], userListFirst[2], userListFirst[3] };

            var result = userListFirst.Except(userListSecond);

            CollectionAssert.AreEqual(expectedData, result.ToList());
        }

        [TestMethod]
        public void SelectsValuesByNameMax()
        {
            var actualData = new List<User>();
            var expectedData = new List<User> { userListSecond[0], userListSecond[2] };

            var result = userListSecond.Where(e => e.Name == "Max");

            CollectionAssert.AreEqual(expectedData, result.ToList());
        }

        [TestMethod]
        public void ContainOrNotContainName()
        {
            var isContain = false;

            //name max 
            //ToDo Add code for second list
            isContain = userListSecond.Contains(userListSecond.FirstOrDefault(e => e.Name == "Max"));
            Assert.IsTrue(isContain);

            // name obama
            //ToDo add code for second list
            isContain = userListSecond.Contains(userListSecond.FirstOrDefault(e => e.Name == "Obama"));
            Assert.IsFalse(isContain);
        }

        [TestMethod]
        public void AllListWithName()
        {
            var isAll = true;

            //name max 
            //ToDo Add code for second list
            isAll = userListSecond.All(e => e.Name == "Max");
            Assert.IsFalse(isAll);
        }

        [TestMethod]
        public void ReturnsOnlyElementByNameMax()
        {
            var actualData = new User();
            
            try
            {
                //ToDo Add code for second list
                //name Max
                userListSecond.Single(e => e.Name == "Max");
                Assert.Fail();
            }
            catch (InvalidOperationException ie)
            {
                Assert.AreEqual("Sequence contains more than one matching element", ie.Message);
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
            
        }

        [TestMethod]
        public void ReturnsOnlyElementByNameNotOnList()
        {
            var actualData = new User();

            try
            {
                //ToDo Add code for second list
                //name Ldfsdfsfd
                userListSecond.First(e => e.Name == "dfgfdgfdg");
                Assert.Fail();
            }
            catch (InvalidOperationException ie)
            {
                Assert.AreEqual("Sequence contains no matching element", ie.Message);
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
            
        }

        [TestMethod]
        public void ReturnsOnlyElementOrDefaultByNameNotOnList()
        {
            var actualData = new User();

            //ToDo Add code for second list

            //name Ldfsdfsfd
            actualData = userListSecond.FirstOrDefault(e => e.Name == "dfgfdgfdg");


            Assert.IsTrue(actualData == null);
        }


        [TestMethod]
        public void ReturnsTheFirstElementByNameNotOnList()
        {
            var actualData = new User();

            try
            {
                //ToDo Add code for second list
                //name Ldfsdfsfd
                actualData = userListSecond.First(e => e.Name == "dfgfdgfdg");
                Assert.Fail();
            }
            catch (InvalidOperationException ie)
            {
                Assert.AreEqual("Sequence contains no matching element", ie.Message);
            }
            catch (Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
            
        }

        [TestMethod]
        public void ReturnsTheFirstElementOrDefaultByNameNotOnList()
        {
            var actualData = new User();

            //ToDo Add code for second list
            //name Ldfsdfsfd
            actualData = userListSecond.FirstOrDefault(e => e.Name == "dfgfdgfdg");

            Assert.IsTrue(actualData == null);
        }

        [TestMethod]
        public void GetMaxSalaryFromFirst()
        {
            var expectedData = 54000;
            var actualData = new User();

            //ToDo Add code for first list
            actualData = userListSecond.FirstOrDefault(e => e.Salary == userListSecond.Max(x => x.Salary));

            Assert.IsTrue(expectedData == actualData.Salary);
        }

        [TestMethod]
        public void GetCountUserWithNameMaxFromSecond()
        {
            var expectedData = 2;
            var actualData = 0;

            //ToDo Add code for second list
            actualData = userListSecond.Count(e => e.Name == "Max");
            Assert.IsTrue(expectedData == actualData);
        }

        [TestMethod]
        public void Join()
        {
            var NameInfo = new[]
            {
                new {name = "Max", Info = "info about Max"},
                new {name = "Alan", Info = "About Alan"},
                new {name = "Alex", Info = "About Alex"}
            }.ToList();

            var expectedData = 3;
            var actualData = -1;

            var expectedResult = new[]
            {
            new
            {
                Name = "Max",
                Salary = (decimal)24000,
                Age = 23,               
                Info="info about Max",                
                Gender = Gender.Man,
            },

            new
            {
                Name = "Max",
                Salary = (decimal)24000,
                Age = 23,
                Info="info about Max",
                Gender = Gender.Man,
            },

            new
            {
                Name = "Alex",
                Salary = (decimal)54000,
                Age = 45,
                Info="About Alex",
                Gender = Gender.Man,
            },

            };

            var result = userListSecond.Join(NameInfo, x => x.Name, y => y.name, (x, y) => 
            new { Name = x.Name, Salary = x.Salary, Age = x.Age, Info = y.Info, Gender = x.Gender }).ToList();
            //ToDo Add code for second lis
            CollectionAssert.AreEqual(expectedResult, result.ToList());
        }
    }
}
