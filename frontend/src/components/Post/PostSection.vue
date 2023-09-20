<script setup lang="ts">

const { heading, body } = defineProps({
    heading: String,
    body: String
})

</script>

<template>
    <div class="text-white flex flex-col gap-5">
        <h1 class="text-2xl font-semibold">{{ heading }}</h1>
        <p>
            {{ body }}
        </p>
    </div>
</template>