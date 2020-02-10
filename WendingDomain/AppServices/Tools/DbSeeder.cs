using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using WendingDomain;
using WendingDomain.Entities;

namespace AppServices.Tools
{
    public static class DbSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var dbContext = serviceProvider.GetRequiredService<WendingDbContext>())
            {
                dbContext.Coins.RemoveRange(dbContext.Coins);
                dbContext.Drinks.RemoveRange(dbContext.Drinks);
                dbContext.Storage.RemoveRange(dbContext.Storage);
                dbContext.WendingMachine.RemoveRange(dbContext.WendingMachine);

                dbContext.WendingMachine.Add(new WendingMachine
                {
                    Balance = 100,
                    Drinks = new List<Drink>
                    {
                        new Drink
                        {
                            Title = "Coca-cola",
                            Price = 10,
                            isAvailable = true,
                            Count = 10,
                            ImageUrl="/images/drinks/cola1.png"
                        },
                        new Drink
                        {
                            Title = "Pepsi",
                            Price = 11,
                            isAvailable = true,
                            Count = 10,
                            ImageUrl="/images/drinks/pepsi.png"
                        },
                        new Drink
                        {
                            Title = "Fanta",
                            Price = 12,
                            isAvailable = true,
                            Count = 10,
                            ImageUrl="/images/drinks/fanta.png"
                        },
                        new Drink
                        {
                            Title = "Sprite",
                            Price = 11,
                            isAvailable = true,
                            Count = 10,
                            ImageUrl="/images/drinks/sprite.png"
                        },
                        new Drink
                        {
                            Title = "Tea",
                            Price = 11,
                            isAvailable = true,
                            Count = 10,
                            ImageUrl="/images/drinks/nestea.png"
                        },
                        new Drink
                        {
                            Title = "Bonaqua",
                            Price = 11,
                            isAvailable = true,
                            Count = 10,
                            ImageUrl="/images/drinks/bonaqua.png"
                        }
                    }
                });

                dbContext.Storage.Add(new CoinStorage
                {
                    CountCoins = 5,
                    Coins = new List<Coin>
                    {
                        new Coin
                        {
                            Value = 1,
                            isAvailable = true,
                            ImageUrl = "coins/1rub.png"
                        },
                        new Coin
                        {
                            Value = 2,
                            isAvailable = true,
                            ImageUrl = "coins/2rub.png"
                        },
                        new Coin
                        {
                            Value = 5,
                            isAvailable = true,
                            ImageUrl = "coins/5rub.png"
                        },
                        new Coin
                        {
                            Value = 10,
                            isAvailable = true,
                            ImageUrl = "coins/10rub.png"
                        }

                    }
                });
                dbContext.SaveChanges();
            }
        }
    }
}



    