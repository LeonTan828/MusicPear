<?php
    $con = mysqli_connect('localhost', 'root', 'root', 'musicpear');

    // Check to seee if the connection was successful
    if (mysqli_connect_errno())
    {
        echo("connection failed");
        exit();
    }

    $searchterm = $_POST["searchterm"];

    $titlesearchquery = "SELECT songID FROM songs WHERE title = '" . $searchterm . "';";
    $titlesearch = mysqli_query($con, $titlesearchquery) or die("title search failed");

    if (mysqli_num_rows($titlesearch) == 0)
    {
        echo("No such title exist");
        exit();
    }

    echo("0");

    while($row = mysqli_fetch_assoc($titlesearch))
    {
        echo($row['songID']);
    }
    // NOTE figure out how to return the search results
?>