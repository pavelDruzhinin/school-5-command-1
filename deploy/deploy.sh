#!/bin/bash

file_name=$1
from_string=$2
to_string=$3

echo "Replace docker tag $from_string to $to_string in file $file_name";

awk '{gsub(/'"$from_string:[[:digit:]]+"'/,"'"$to_string"'")}1' $file_name > temp.txt 
mv temp.txt $file_name
rm -rf temp.txt

docker-compose -f $file_name up -d
