# ssh-buttons
GUI app (GUI in the future) which allows you tu run commands over ssh just with buttons.

## Configuration files
They are two config files.

> [!IMPORTANT]  
> If you are using older version, below are config examples for older versions

### config.json
In config.json, you can set hostname and username for ssh connection.
```json
{
  "hostname": "example.com",
  "username": "user"
}
```
Program can ask user anything of this, if you want to. Just set `askUser` as value.
```json
{
  "hostname": "askUser",
  "username": "askUser"
}
```
In this case, program will ask user both hostname and username.

### commands.txt
In this simple txt file, on odd lines are command descriptions (text which will be visible to user on button) and on even lines are commands which will be executed on server.

For example:
```
First command
echo first
Second command
echo second
```

There can be as much commands as you want, but remember, odd lines = command description; even lines = commands which will be executed on server.

## Configuration files for older versions

### Configuration file for v0.1
There is one config file in json which is config.json. It's the order that matters, not the name of the elements.

Example:
```json
{
  "hostname": "example.com",
  "username": "user",
  "firstCommandDescription": "First command",
  "firstCommand": "echo First command",
  "secondCommandDescription": "Second command",
  "secondCommand": "echo \"second command\"",
  "XCommandDescription": "X command",
  "XCommand": "echo X command"
}
```