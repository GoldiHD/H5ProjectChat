#!/bin/bash

echo "Cleaning Chatter"
if [ -e ./Setup.sh ] 
then
	rm  ./Setup.sh
else
	echo "No files to remove"
fi
echo "Starting up Chatter API"
./Chatter/Publish/H5ProjectChatAPI
echo "Chatter API runnning"
