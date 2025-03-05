<script>
        function calculateCalories() {
            var workoutId = document.getElementById("workoutId").value;
        $.ajax({
            type: "POST",
        url: "@Url.Page("/Details", "CalculateCalories")",
        data: {id: workoutId },
        success: function (response) {
            $("#caloriesResult").text("Total Calories Burned: " + response.totalCaloriesBurned);
        $("#caloriesResult").show();
                },
        error: function () {
            $("#caloriesResult").text("Error calculating calories burned.");
        $("#caloriesResult").show();
                }
            });
        }
</script>
