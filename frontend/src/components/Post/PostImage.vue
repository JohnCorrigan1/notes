<script setup lang="ts">
const { src, alt } = defineProps({
    src: String,
    alt: String,
    caption: String
})
</script>

<template>
    <div class="w-full flex flex-col justify-center items-center pt-10 gap-2">
        <img :src="src" :alt="alt" class="object-cover" />
        <caption :v-if="caption != ''" class="w-full text-center text-slate-500 italic text-sm">{{ caption }}</caption>
    </div>
</template>