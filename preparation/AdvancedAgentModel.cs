using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace preparation
{
    internal class AdvancedAgentModel
    {
        private readonly poprizhenokEntities poprizhenokEntities1;

        public AdvancedAgentModel(poprizhenokEntities poprizhenokEntities)
        {
            this.poprizhenokEntities1 = poprizhenokEntities;
        }

        public Agents agents(int id) => poprizhenokEntities.GetContext().Agents.FirstOrDefault(p => p.ИН_Агента == id);
        public int CountOfSales(int id) => Convert.ToInt32(poprizhenokEntities.GetContext().productsale.Where(p => p.ИН_Агента == id && p.Дата.Value.Year >= DateTime.Today.Year).Sum(p => p.Кол_во));
        public int AgentSale(int id)
        {
            int Count = Convert.ToInt32(poprizhenokEntities.GetContext().productsale.Where(p => p.ИН_Агента == id).Sum(p => p.Кол_во));
            if (Count >= 500) return 25;
            else if (Count >= 150) return 20;
            else if (Count >= 50) return 10;
            else if (Count >= 10) return 5;
            else return 0;
        }
    }
}
