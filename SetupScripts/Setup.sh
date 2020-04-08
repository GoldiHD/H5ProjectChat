#!/bin/bash

echo "Beginning setup"
mkdir Chatter
apt-get update
apt-get upgrade
apt-get install sqlite3
sqlite3 Chatdatabase.db <<EOF
CREATE TABLE users(id integer primary key, username text, password text, lastLogin text);
CREATE TABLE chatData(id integer primary key, userid integer, message text, postTime text);
EOF
mv ./Chatdatabase.db ./Chatter/
mv ./publish/Chatter.sh ./
mv ./publish ./Chatter/
echo "Setup is completed"
