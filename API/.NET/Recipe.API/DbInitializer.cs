using System;
using System.Linq;

namespace Recipe.API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(RecipeContext context)
        {
            // context.Database.EnsureCreated();
            
            // // context.Recipes.RemoveRange(context.Recipes);

            // context.SaveChanges();

            // // Look for any recipes.
            // if (!context.Recipes.Any())
            // {
            //     var recipes = new Recipe[]
            //     {
            //         new Recipe {
            //             Title = "Test Title - 1",
            //             Instructions = new List<Instruction> {
            //                 new Instruction {
            //                     Text = "Chop up the fruit"
            //                 }
            //             }
            //         },
            //         new Recipe {
            //             Title = "Test Title - 2"
            //         },
            //     };

            //     context.AddRange(recipes);
            // }

            // if (!context.Planning.Any())
            // {
            //     var planItems = new PlanItem[]
            //     {
            //         new PlanItem {
            //             Text = "Test",
            //             Type = PlanItemType.GroceryList
            //         },
            //         new PlanItem {
            //             Text = "Kitchen Item",
            //             Type = PlanItemType.Kitchen
            //         }
            //     };

            //     context.AddRange(planItems);
            // }
            
            // context.SaveChanges();
        }
    }

    // public static int updateTimes(List<int> signalOne, List<int> signalTwo)
    // {
    //     int maxEqual = 0;
    //     int times = 0;
        
    //     List<int> shorterSignal = signalOne.Count() > signalTwo.Count() ? signalOne : signalTwo;
    //     List<int> longerSignal = signalOne.Count() < signalTwo.Count() ? signalOne : signalTwo;
        
    //     int numberOfTimes = 0;
    //     for (int i = 0; i < shorterSignal.Count(); i++)
    //     {
    //         if (shorterSignal[i] == longerSignal[i])
    //         {
    //             if (maxEqual < shorterSignal[i])
    //             {
    //                 maxEqual = shorterSignal[i];
    //                 times += 1;
    //             }
    //         }
    //     }
        
    //     return times;
    // }
}
