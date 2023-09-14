<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import HelloWorld from './components/HelloWorld.vue'
import { ref } from 'vue'

interface Comment {
  user: User;
  body: string;
  postedDate: string;
}
interface Author {
  username: string;
  id: number;
}

interface User {
  username: string;
  id: number;
}

interface Post {
  body: string;
  postedDate: string;
  comments: Comment[];
  author: Author;
  likes: number;
  id: number;
}

const date = ref("");
const temp = ref("");
const tempF = ref("");
const summary = ref("");

const top3 = ref<Post[]>();

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

const getTop3: any = async () => {
  fetch("https://johnnotesapi.azurewebsites.net/api/Post/top3")
  // fetch("https://localhost:7010/api/Post/top3")
    .then(response => {
      // console.log(response.json());
      if(!response.ok) {
        throw new Error("HTTP error " + response.status);
      }
      return response.json();
    })
    .then(data => {
      console.log(JSON.stringify(data));
      top3.value = JSON.parse(JSON.stringify(data)) as Post[];
      console.log(top3.value)
    });
}

</script>

<template>
     <div>
        <button @click="getWeather">Get weather local</button>
        <p>{{date}}</p>
        <p>{{temp}}</p>
        <p>{{tempF}}</p>
        <p>{{summary}}</p>
      </div>

      <div>
        <button @click="getTop3">Get top3</button>
        <div :key="post.id" v-for="post in top3">
          <p>{{post.body}}</p>
          <p>{{post.postedDate}}</p>
          <p>{{post.author.username}}</p>
          <p>{{post.likes}}</p>
        </div> 
      </div>

  <!-- <RouterView /> -->
</template>