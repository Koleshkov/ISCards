using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using ISCards.Common.Mappings;
using ISCards.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCards.Models
{
    public partial class BaseCardDTO : BaseDTO
    {
        
        private string cardTitle="";
        public string CardTitle
        {
            get
            {
                return cardTitle;
            }
            set
            {
                cardTitle = value;
                OnPropertyChanged(nameof(CardTitle));
            }
        }

        private string cardName="";
        public string CardName
        {
            get
            {
                return cardName;
            }
            set
            {
                cardName = value;
                OnPropertyChanged(nameof(CardName));
            }
        }
        public string CardType { get; set; }

        private string creatorName="";
        public string CreatorName
        {
            get
            {
                return creatorName;
            }
            set
            {
                creatorName = value;
                CardName = $"{CardType} {value} {CreationDate.ToShortDateString()}";
                OnPropertyChanged(nameof(CreatorName));
            }
        }

        private DateTime creationDate = DateTime.Now;
        public DateTime CreationDate
        {
            get
            {
                return creationDate;
            }
            set
            {
                creationDate = value;
                CardName=$"{CardType} {CreatorName} {value.ToShortDateString()}";
                CardTitle = $"{CardType} {value}";
                OnPropertyChanged(nameof(CreationDate));
            }
        }

        [ObservableProperty]
        private string respName="";

        [ObservableProperty]
        private DateTime deadline = DateTime.Now;

        public BaseCardDTO(string cardType)
        {
            CardType=cardType;
        }

    }
}
