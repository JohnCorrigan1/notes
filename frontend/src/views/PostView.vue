<script setup lang="ts">
import { ref } from 'vue'
import { useRoute } from 'vue-router';

const route = useRoute();
const title = route.params.title
console.log(title)
</script>

<template>
    <main class="">
        <h1></h1>
    </main>
</template>
