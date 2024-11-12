using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EZSave.Main.Infrastructure.AutoVMBinding;
using EZSave.Model.PlanTemplateData;

namespace EZSave.Main.ViewModels
{
    public partial class PlanTemplateSelectionControlViewModel : ViewModelBase
    {
        [ObservableProperty]
        private List<CardModel> _dataList;

        public PlanTemplateSelectionControlViewModel()
        {
            DataList = GetCardDataList();
        }

        public List<CardModel> GetCardDataList()
        {
            return new List<CardModel>
            {
                new CardModel
                {
                    Header = "Atomic",
                    Content = "1.jpg",
                    Footer = "Stive Morgan"
                },
                new CardModel
                {
                    Header = "Zinderlong",
                    Content = "2.jpg",
                    Footer = "Zonderling"
                },
                new CardModel
                {
                    Header = "Busy Doin' Nothin'",
                    Content = "3.jpg",
                    Footer = "Ace Wilder"
                },
                new CardModel
                {
                    Header = "Wrong",
                    Content = "4.jpg",
                    Footer = "Blaxy Girls"
                },
                new CardModel
                {
                    Header = "The Lights",
                    Content = "5.jpg",
                    Footer = "Panda Eyes"
                },
                new CardModel
                {
                    Header = "EA7-50-Cent Disco",
                    Content = "6.jpg",
                    Footer = "еяхат музыка"
                },
                new CardModel
                {
                    Header = "Monsters",
                    Content = "7.jpg",
                    Footer = "Different Heaven"
                },
                new CardModel
                {
                    Header = "Gangsta Walk",
                    Content = "8.jpg",
                    Footer = "Illusionize"
                },
                new CardModel
                {
                    Header = "Won't Back Down",
                    Content = "9.jpg",
                    Footer = "Boehm"
                },
                new CardModel
                {
                    Header = "Katchi",
                    Content = "10.jpg",
                    Footer = "Ofenbach"
                }
            };
        }

        public override void ViewWindowInit()
        {
            throw new NotImplementedException();
        }

        [RelayCommand]
        public void SelectPlanTemplate()
        {

        }
    }
}