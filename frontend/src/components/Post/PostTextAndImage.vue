<script setup lang="ts">
const { body } = defineProps({
    body: String,
    src: String,
    alt: String,
    caption: String
});
</script>

<template>
    <div class="text-white flex gap-5 pt-10 items-center">
        <p class=" w-4/5">
            {{ body }}
        </p>
        <div class="flex flex-col gap-2">
            <img :src="src" :alt="alt" />
            <caption :v-if="caption != '' || caption" class="w-full text-center text-slate-500 italic text-sm">{{ caption }}
            </caption>
        </div>

    </div>
</template>