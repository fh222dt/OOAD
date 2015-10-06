using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPirateRegistry.controller
{
    class Controller
    {
        public bool Start (view.MainView a_view, model.Registry a_model)
        {
            model.Member selectedMember = null;
            model.Boat selectedBoat = null;

            a_view.ShowStartMenu();

            switch (a_view.userInput())
            {
                case 0:   //exit
                    return false;

                case 1:     //add member
                    model.Member memberToAdd = a_view.m_memberView.AddMember();
                    a_model.AddMember(memberToAdd);
                    a_view.ShowGoBackMenu();                    
                    break;

                case 2: //select member
                    a_view.ShowCompactList(a_model.m_members);
                    int memberToBeselected = a_view.m_memberView.SelectMember();    
                    selectedMember =  a_model.SelectMember(memberToBeselected);

                    if (selectedMember != null)
                    {
                        switch (a_view.m_memberView.MemberMenu(selectedMember))
                        {
                            case 1:             //delete
                                model.Member memberToDel = a_view.m_memberView.DeleteMember(selectedMember);
                                a_model.DeleteMember(memberToDel);
                                break;

                            case 2:     //update 
                                model.Member memberToUpdate = a_view.m_memberView.UpdateMember(selectedMember);                          
                                a_model.UpdateMember(selectedMember, memberToUpdate);
                                a_view.ShowGoBackMenu();
                                break;

                            case 3:     //add boat
                                model.Boat boatToAdd = a_view.m_boatView.addBoat();
                                selectedMember.AddBoat(boatToAdd);
                                a_view.ShowGoBackMenu();
                                break;

                            case 4:     //select boat of member
                                int boatToBeSelected = a_view.m_boatView.SelectBoat(selectedMember);
                                selectedBoat = selectedMember.SelectBoat(boatToBeSelected);

                                if(selectedBoat != null)
                                {
                                    switch(a_view.m_boatView.BoatMenu(selectedBoat))
                                    {
                                        case 1:     //delete boat
                                            model.Boat boatToDel = a_view.m_boatView.DeleteBoat(selectedBoat, selectedMember);
                                            selectedMember.DeleteBoat(boatToDel);
                                            break;

                                        case 2:     //update boat
                                            model.Boat boatToUpdate = a_view.m_boatView.UpdateBoat(selectedBoat);
                                            selectedMember.UpdateBoat(selectedBoat, boatToUpdate);
                                            a_view.ShowGoBackMenu();
                                            break;
                                    }
                                }

                                break;
                        }
                    }

                    break;         
                    
                case 3: //compact list
                    a_view.ShowCompactList(a_model.m_members);
                    a_view.ShowGoBackMenu();
                    break;

                case 4: //verbose list
                    a_view.ShowVerboseList(a_model.m_members);
                    a_view.ShowGoBackMenu();
                    break;

            }

            return true;
        }
    }
}
