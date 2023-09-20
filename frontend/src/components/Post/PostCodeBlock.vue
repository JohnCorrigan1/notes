<script setup lang="ts">

const { language, code } = defineProps({
    language: String,
    code: String
})
const onCode = () => {
    const gamerCode = document.getElementById("gamerCode") as HTMLCodeElement
    console.log(gamerCode)
}

</script>

<template>
    <div class="flex flex-col gap-5 py-10">
        <code @click="onCode" id="gamerCode" class="bg-slate-700 bg-opacity-30 p-10 rounded-md">
                                                {{ code }}
                                            </code>
    </div>
</template>