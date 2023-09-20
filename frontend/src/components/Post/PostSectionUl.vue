<script setup lang="ts">

const { heading, items } = defineProps({
    heading: String,
    items: Array,
    subheading: String
})

</script>

<template>
    <div class="text-white flex flex-col gap-5 pt-10">
        <h1 :v-if="heading != ''" class="text-2xl font-semibold">{{ heading }}</h1>
        <h2 :v-if="subheading != ''" class="text-xl font-semibold">{{ subheading }}</h2>
        <ul class="pl-10">
            <li class="list-disc" v-for="item, index in items" :key="index">
                {{ item }}
            </li>
        </ul>
    </div>
</template>