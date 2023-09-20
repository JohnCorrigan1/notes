<script setup lang="ts">

const { items } = defineProps({
    items: Array
})

</script>

<template>
    <ol class="list-decimal list-inside w-full flex flex-col items-center pt-10">
        <li v-for="item, index in items" :key="index">
            {{ item }}
        </li>
    </ol>
</template>