<?php

define('DB_NAME', 'trprt_test');
define('DB_USER', 'root');
define('DB_PASSWORD','phoenix');
define('DB_HOST', 'localhost:3306');

$link = mysql_connect(DB_HOST, DB_USER, DB_PASSWORD);

if(!$link){
  die('Could not connect: ' . mysql_error());
}

$db_selected = mysql_select_db(DB_Name, $link);

if(!db_selected){
  die('Cannot use' . DB_Name . ':' . mysql_error());
}

$form_id = $_POST['form_id'];
$referral_form_id = $_POST['referral_form_id'];
$client = $_POST['client'];
$income = $_POST['income'];

$sql = "INSERT INTO referralslipphpmyadmin (form_id, referral_form_id, client, income) VALUES ('$form_id', '$referall_form_id', 'client', '$income')";

if(!mysql_query($sql)){
  die('Error: ' . mysql_error());
}

mysql_close();

?>
