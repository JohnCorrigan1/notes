<script setup >
import HighLight from "vue3-highlight-component";
import 'highlight.js/styles/tokyo-night-dark.css';
import { onMounted } from "vue";

const copyCode = () => {
    const tempTextArea = document.createElement('textarea');
    tempTextArea.value = code;
    document.body.appendChild(tempTextArea);
    tempTextArea.select();
    document.execCommand('copy');
    document.body.removeChild(tempTextArea);
}
onMounted(() => {
    const codeEl = document.querySelector('code');
    codeEl.classList.remove('code-box');
    const pre = document.querySelector('pre');
    pre.style.display = 'flex';
    pre.style.alignItems = 'center';
    pre.style.padding = '10px';
})

const {
    language,
    code
} = defineProps({
    language: String,
    code: String
})
</script>

<template>
    <div class="flex flex-col justify-center gap-5 pt-5">
        <div class="hljs p-5 flex items-center relative">
            <button class="absolute top-3 right-3" @click="copyCode"><img src="/copyIcon.svg" alt="Copy"
                    class="object-cover opacity-50 hover:opacity-100 active:scale-95 duration-200 h-6" /></button>
            <!-- <highlightjs id="codeBlock" ref="codeBlock" v-code :autodetect="language === ''" :code="code" -->
            <!-- :language="language"> -->
            <!-- </highlightjs> -->
            <HighLight language="javascript" lang="js" :code="code" />
        </div>
    </div>
</template>

<style scoped>
.hljs {
    border-radius: 10px;
    overflow: auto;
}
</style>
