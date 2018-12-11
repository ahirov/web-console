# WebConsole
This tool allows you to work with a console application on the remote server from your web browser<br />
**Live version:** https://webconsoletrial.azurewebsites.net/ (very slow via the free trial plan)<br /><br />
![Overview](https://github.com/hirov-anton/web-console/blob/master/content/overview.gif)
## Deployment
**1.** Clone this repo to your local machine (master branch)<br />
**2.** Attach a console application type in `GlobalController.GetInfos` action<br />
```
var jobs = new List<Type>
{
    typeof(Console.Program),
    typeof(ConsoleWithError.Program)
};
```
or set `WebConsole.config` file in the root directory
```
<configuration>
  <settings>
    <jobsLimit>12</jobsLimit>
  </settings>
  <jobs>
    <job namespace="Sandbox" location="%SANDBOX%\ExternalConsole.exe">
      ExternalConsole
    </job>
  </jobs>
</configuration>
```
where `Sandbox.ExternalConsole` - full name of an application,<br />
`jobsLimit` - maximum number of simultaneously working consoles<br /><br />
**3.** Publish WebConsole application...

## Usage
- **`Execute`** - run the selected application with specified arguments<br />
- **`Mode`** - change view mode (one or four work areas)<br />
- **`Statistics`** - view info about all console applications (this and other sessions)<br />
- **`Stop all`** - stop console applications only in your session<br />

## Support
**Anton Hirov:** [Messenger](https://m.me/hirov.anton) or [Email](mailto:hirov.anton@yahoo.com)
