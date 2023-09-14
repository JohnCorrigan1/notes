<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import HelloWorld from './components/HelloWorld.vue'
import { ref } from 'vue'

const date = ref("");
const temp = ref("");
const tempF = ref("");
const summary = ref("");

// const getWeather = async () => {
  // const weather = await fetch("https://localhost:7010/WeatherForecast")
  // console.log(weather);
// }
const getWeather: any = async () => {
  fetch("https://localhost:7010/WeatherForecast")
    .then(response => {
      // console.log(response.json());
      if(!response.ok) {
        throw new Error("HTTP error " + response.status);
      }
      return response.json();
    })
    .then(data => {
      console.log(JSON.stringify(data));
      date.value = data[0].date;
      temp.value = data[0].temperatureC;
      tempF.value = data[0].temperatureF;
      summary.value = data[0].summary;
    });
}

</script>

<template>
     <div>
        <button @click="getWeather">Get weather</button>
        <p>{{date}}</p>
        <p>{{temp}}</p>
        <p>{{tempF}}</p>
        <p>{{summary}}</p>
      </div>

  <!-- <RouterView /> -->
</template>