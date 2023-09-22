<script setup lang="ts">
import type { ComponentPreview } from '@/types/types';

const { componentPreview } = defineProps({
    componentPreview: Object as () => ComponentPreview
});

</script>

<template>
    <div class="flex flex-col  bg-zinc-600 bg-opacity-40 rounded-lg cursor-pointer hover:bg-opacity-25 duration-200">
        <img class="h-2/3 rounded-t-lg" :src="componentPreview?.src" :alt="componentPreview?.name" />
        <div class="w-full h-1/3 flex justify-center items-center">
            <p class="">{{ componentPreview?.name }}</p>
        </div>
    </div>
</template>