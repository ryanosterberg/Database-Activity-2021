using CodeTheWay.Web.Ui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTheWay.Web.Ui.Repositories
{
    public class ShippingContainerRepository: IShippingContainerRepository
    {
        private AppDbContext AppDbContext;

        public ShippingContainerRepository(AppDbContext dbContext)
        {
            this.AppDbContext = dbContext;
        }

        public async Task<ShippingContainer> Create(ShippingContainer box)
        {
            var result = await this.AppDbContext.AddAsync(box);
            await this.AppDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<List<ShippingContainer>> GetShippingContainers()
        {
            return await this.AppDbContext.ShippingContainer.ToListAsync();
        }
        public async Task<ShippingContainer> GetShippingContainer(Guid id)
        {
            return await AppDbContext.ShippingContainer.FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<ShippingContainer> Update(ShippingContainer box)
        {
            var result = AppDbContext.ShippingContainer.Update(box);
            await AppDbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<ShippingContainer> Delete(ShippingContainer box)
        {
            AppDbContext.ShippingContainer.Remove(box);
            await AppDbContext.SaveChangesAsync();
            return box;
        }

    }
}
