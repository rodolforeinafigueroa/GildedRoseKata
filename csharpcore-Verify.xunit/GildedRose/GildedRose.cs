using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private const string AGED_BRIE = "Aged Brie";
        private const string BACKSTAGE_PASSES = "Backstage passes to a TAFKAL80ETC concert";
        private const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        private const string CONJURED = "Conjured Mana Cake";
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateItem(item);
            }
        }

        private void UpdateItem(Item item)
        {
            if (item.Name == SULFURAS)
            {
                return;
            }

            item.SellIn = item.SellIn - 1;
            bool hasExpired = item.SellIn < 0;
            var qualityAdjustment = hasExpired ? -2 : -1;

            if (item.Name == AGED_BRIE)
            {
                qualityAdjustment = hasExpired ? 2 : 1;
                AdjustQuality(item, qualityAdjustment);
                return;
            }

            if (item.Name == BACKSTAGE_PASSES)
            {
                if (hasExpired)
                {
                    qualityAdjustment = -item.Quality;
                }
                else
                {
                    qualityAdjustment = 1;

                    if (item.SellIn < 10)
                    {
                        qualityAdjustment++;
                    }

                    if (item.SellIn < 5)
                    {
                        qualityAdjustment++;
                    }
                }
                AdjustQuality(item, qualityAdjustment);
                return;
            }

            if (item.Name == CONJURED)
            {
                AdjustQuality(item, qualityAdjustment);
                return;
            }

            AdjustQuality(item, qualityAdjustment);
        }

        private void AdjustQuality(Item item, int adjustment)
        {
            item.Quality = item.Quality + adjustment;
            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }
    }
}
