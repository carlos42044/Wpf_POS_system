# WPF POS System
### Documentation
###### August 2017
###### Compuflex
###### 30 Hillside Avenue, Springfield, New Jersey 07081


## About this Document
This is document is intended as a source of reference for users of __WPF POS System__. This reference guide consists of all the features and functions present in the application. 
The purpose of this document is to support the **WPF POS System User**.

## What is WPF POS System?
The WPF POS System is a mock POS System application emulating functionality of existing commercial POS Systems available. This application was developed with the intent to be used for testing/developing of a larger screen engine management software.

This software aims to provide real world features one might encounter when working with commercially available POS Systems.

## How Does it Work?
THhis application provides a simple and user friendly interface to simulate "Employee users", adding items to a cart, and finally processing payment while saving transaction history.

## Glossary of Key Terms
| **Term**       | Definition                                                                                                                                                      |
|----------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **WPF**        | Windows Presentation Foundation. a graphical subsystem by Microsoft for rendering user interfaces in Windows-based applications.                                |
| **POS System** | Point of Sales System, (in this case only software) allows a merchant to calculate the amount owed by a customer, handle payment, and save transaction history. |
| **Trans**      | Shorthand for Transaction, Trans tab displays the transaction history. |

## Action Buttons
| Icon                               | Action                                                                                                                                                                                            |
|------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| ![Name Label][label]               | Label that displays an "employee's" name.                                                                                                                                                         |
| ![Time Label][timeStamp]           | Displays the current time, used for transaction history.                                                                                                                                          |
| ![Add Button][addBtn]              | Adds a random nut product to the cart (quantity is also random).                                                                                                                                  |
| ![Clear Button][clearBtn]          | Clears the cart of all items.                                                                                                                                                                     |
| ![Total Label][totalLabel]         | Displays the updated total for the current transaction.                                                                                                                                           |
| ![Pay Button][payBtn]              | When clicked it gives the user the option to pay in-window or through a popup window. (Option for in-window/popup window located in settings)                                                     |
| ![TenderInWindow][tenderInWindow]  | Visible once the ![Pay Button][payBtn] is clicked, a text box where a user can enter payment in the format x.xx .                                                                                 |
| ![Process][processBtn]             | Once the user enters enough money, the user may process the transaction. Each transaction is saved in the 'Trans' tab. **Note:** Once the application is closed, all transaction history is lost. |
| ![tabs][tabs]                      | Tabs, the first shows the items currently in the cart. The second tab 'Trans' displays transaction history.                                                                                       |
| ![Settings][settings]              | When a user right-clicks, a settings window will appear.                                                                                                                                          |
| ![payWindow][payWindow]            | Based on what option is selected in the settings menu, the pay window may appear for a user to process payment.                                                                                   |
| ![Settings Window][settingsWindow] | Settings window, a user can choose how the "employee's" name is displayed. The name can be displayed as a label, image, in a drop down container, or as a button. (Default is set to labels).     |
| ![Empty Cart][emptyCart]           | An example of what an empty cart screen looks like.                                                                                                                                               |
| ![Empty Transaction][emptyTrans]   | An example of what an empty transaction screen looks like.                                                                                                                                        |


[label]: https://github.com/carlos42044/Wpf_POS_system/blob/master/img/label.PNG "Label"
[timeStamp]: https://github.com/carlos42044/Wpf_POS_system/blob/master/img/timeStamp.PNG "Time Stamp"
[addBtn]: https://github.com/carlos42044/Wpf_POS_system/blob/master/img/addBtn.PNG "Add Button"
[clearBtn]: https://github.com/carlos42044/Wpf_POS_system/blob/master/img/clearBtn.PNG "Clear Button"
[totalLabel]: https://github.com/carlos42044/Wpf_POS_system/blob/master/img/totalLabel.PNG "Total Label"
[payBtn]: https://github.com/carlos42044/Wpf_POS_system/blob/master/img/payBtn.PNG "Pay Button"
[tenderInWindow]: https://github.com/carlos42044/Wpf_POS_system/blob/master/img/tenderInWindow.PNG "Tender in Window"
[processBtn]: https://github.com/carlos42044/Wpf_POS_system/blob/master/img/processBtn.PNG "Process Button"
[tabs]: https://github.com/carlos42044/Wpf_POS_system/blob/master/img/tabs.PNG "Tabs"
[settings]: https://github.com/carlos42044/Wpf_POS_system/blob/master/img/settings.PNG "Settings"
[payWindow]: https://github.com/carlos42044/Wpf_POS_system/blob/master/img/payWindow.PNG "Pay Window"
[settingsWindow]: https://github.com/carlos42044/Wpf_POS_system/blob/master/img/settingsWindow.PNG "Settings Window"
[emptyCart]: https://github.com/carlos42044/Wpf_POS_system/blob/master/img/emptyCartScreen.PNG "Empty Cart Screen"
[emptyTrans]: https://github.com/carlos42044/Wpf_POS_system/blob/master/img/emptyTransScreen.PNG "Empty Trans Screen"








