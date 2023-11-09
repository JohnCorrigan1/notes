<script setup >
// import hljs from "highlight.js"
// import 'highlight.js/lib/common';
// import js from 'highlight.js/lib/languages/javascript';
import HighLight from "vue3-highlight-component";
// import js from 'highlight.js/lib/languages/javascript';
import 'highlight.js/styles/tokyo-night-dark.css';
// import 'highlight.js/styles/atom-one-dark.css'
// import 'highlight.js/styles/arduino-light.css'
// import { HighCode } from 'vue-highlight-code';
// import 'vue-highlight-code/dist/style.css';
import { onBeforeMount } from "vue";
// hljs.
onBeforeMount(() => {
    // hljs.initHighlighting();
    // hljs.registerLanguage('js', js)
})
// const copyCode = () => {
//     // const codeToCopy = document.getElementById("codeBlock")!.innerText;
//     const tempTextArea = document.createElement('textarea');
//     tempTextArea.value = codeToCopy;
//     document.body.appendChild(tempTextArea);
//     tempTextArea.select();
//     document.execCommand('copy');
//     document.body.removeChild(tempTextArea);
// }

const codeEl = document.querySelector('code');
// code.El.style.backgroundColor = 'red';
// codeEl.classList.remove('code-box');

const {
    language,
    code
} = defineProps({
    language: String,
    code: String
})
</script>

<template>
    <div class="flex flex-col gap-5 pt-5">
        <!-- <div class="hljs p-5 relative"> -->
        <!-- <button class="absolute top-3 right-3" @click="copyCode"><img src="/copyIcon.svg" alt="Copy" -->
        <!-- class="object-cover opacity-50 hover:opacity-100 active:scale-95 duration-200 h-6" /></button> -->
        <!-- <highlightjs id="codeBlock" ref="codeBlock" v-code :autodetect="language === ''" :code="code" -->
        <!-- :language="language"> -->
        <!-- </highlightjs> -->
        <!-- <highlightjs autodetect :code="code" id="codeBlock" ref="codeBlock" v-code /> -->
        <!-- <HighCode autodetect class="bg-white" langName="alkdsjfgsda;lkfj" :copy="false" :codeValue="code" /> -->
        <HighLight language="javascript" lang="js" :code="code" />
        <!-- </div> -->
    </div>
</template>

<style scoped>
pre {
    background-color: red;
}

code {
    background-color: red;
}

.hljs {
    background-color: red;
    border-radius: 10px;
    overflow: auto;
}
</style>
