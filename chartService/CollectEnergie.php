<?php

header('Content-Type: application/json');

$con = mysqli_connect("localhost","userVeloPublic","userVeloPublic","veloinfospublic");


// Récupere l'id du cycliste
$id = $_GET["id_cycliste"];
// Check connection
if (mysqli_connect_errno($con))
{
    echo "Failed to connect to DataBase: " . mysqli_connect_error();
}else
{
    $data_points = array();
    $result = mysqli_query($con, "SELECT temps,productionEnergie FROM releve where cycliste_id=".$id);

    while ($row = $result->fetch_assoc()) {
        $point = array("label" => $row['temps'] , "y" => $row['productionEnergie']);
        array_push($data_points, $point);
    }
    echo json_encode($data_points, JSON_NUMERIC_CHECK);
}
// Fermeture de la connexion sql
mysqli_close($con);

?>
