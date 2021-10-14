using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FizBuzz.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizBuzz.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider service)
        {
            using (var context = new FizBuzzContext(
                    service.GetRequiredService<
                        DbContextOptions<FizBuzzContext>>()))
            {
                if (context.NumTable.Any())
                {
                    return;
                }                
                for (int i = 1; i <= 100; i++)
                {
                    
                    String NumString = getFizzBuzz(i);
                   

                    context.NumTable.AddRange(
                        new NumTable
                        {
                            Num = NumString
                            
                        }

                    );
                    context.SaveChanges();


                }
                
                
            }
        }

        public static String getFizzBuzz(int i)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                return "FizzBuzz";

            }
            else if (i % 3 == 0)
            {
                return "Fizz";
            }
            else if (i % 5 == 0)
            {
                return "Buzz";
            }
            else
            {
                return i.ToString();
            }

        }

    }
    
}



   

            

    
