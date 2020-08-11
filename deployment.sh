# Step to deploy code INT for staging server:
# 1. Run script to backup current source code.
# 2. Run script copy file to server
# 3. Run script install node_modules
# 4. Run script start server

# Export static variable
export ec2_host=ubuntu@3.17.161.159
export ec2_ppk=./ran_online.ppk
export rootDirectory=source
# Echo start deployment
echo 'Start deployment for '$env' server - '$ec2_host
rm -rf BE/RanOnlineCore/bin
rm -rf BE/RanOnlineCore/published
rm -rf BE/RanOnlineCore/obj
rm -rf ./Deploy
rm -rf ./Deploy.zip

mkdir Deploy
echo 'Buiding back end'
cd BE/RanOnlineCore && dotnet publish -o ./published -r linux-x64 && cd ../..
echo 'copy source to server'
cd Deploy && mkdir BE
cd ..
cp -r ./BE/RanOnlineCore/bin/Debug/netcoreapp2.1/linux-x64/ ./Deploy/BE
echo 'Building front-end'
#cd FE && npm i && npm run build && cd ..
cp -r ./FE/dist/FE/ ./Deploy
echo 'zip file'
7z a -tzip deploy.zip ./Deploy/*
echo 'set permission writeable'
plink -i $ec2_ppk $ec2_host "mkdir ./avenger_new && sudo chmod 777 ./avenger_new"
echo 'Copy source code to server'
