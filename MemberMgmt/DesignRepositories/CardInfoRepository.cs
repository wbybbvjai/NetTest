﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemberMgmt.Models;

namespace MemberMgmt.DesignRepositories
{
    class CardInfoRepository : IRepositories.ICardInfoRepository
    {
        public CardInfo GetOne()
        {
            return new CardInfo {
                CardNum = "001",
                Name = "张三",
                IdCardNum="140112198106121715"

            };
        }
    }
}
