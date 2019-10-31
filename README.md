# marantz-control-mp-plugin

Marantz Control MediaPortal Plugin
Marantz Control is a plugin for MediaPortal1 to send telnet command on a specific mediaportal action.
It is created with the purpose to change input on my Marantz AVR on a specific mediaportal input (eg: by pressing a remote button).


Instructions

In the plugin config you must select the action from the list, then write the ip address of your AVR and the port (usually 23), plus the telent command you want to send to the AVR. (eg: in my case i want to change input to AUX1 so the is "SIAUX1").
In the mediaportal config you have to set a button of the remote (or keyboard or jypad or any other input device) for the action you have selected in pluginconfig. Pay attention that the action could do also mothing else in MP.
In my setup I choose ACTION_HOME and setup MCE green button accordingly, so when I press the green button on the MCE remote MP goes to Home and switch AVR input to Mediaportal.







