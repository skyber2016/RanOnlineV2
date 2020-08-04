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

echo 'unzip'
plink -i $ec2_ppk $ec2_host "cd avenger && unzip deploy.zip"
echo "Starting server"
plink -i $ec2_ppk $ec2_host 'pm2 del api';
plink -i $ec2_ppk $ec2_host 'cd ./avenger/BE/linux-x64 && pm2 start "dotnet RanOnlineCore.dll" --name "api"';
plink -i $ec2_ppk $ec2_host 'pm2 del http-server';
plink -i $ec2_ppk $ec2_host 'cd ./avenger/FE && sudo pm2 start http-server -p 8080';
plink -i $ec2_ppk $ec2_host 'pm2 save';
echo 'Press [Enter] key to continue...'
read