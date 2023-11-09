<script setup lang="ts">
import 'highlight.js/lib/common';
import 'highlight.js/styles/tokyo-night-dark.css';

const copyCode = () => {
    const codeToCopy = document.getElementById("codeBlock")!.innerText;
    const tempTextArea = document.createElement('textarea');
    tempTextArea.value = codeToCopy;
    document.body.appendChild(tempTextArea);
    tempTextArea.select();
    document.execCommand('copy');
    document.body.removeChild(tempTextArea);
}

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
        <div class="hljs p-5 relative">
            <button class="absolute top-3 right-3" @click="copyCode"><img src="/copyIcon.svg" alt="Copy"
                    class="object-cover opacity-50 hover:opacity-100 active:scale-95 duration-200 h-6" /></button>
            <!-- <highlightjs id="codeBlock" ref="codeBlock" v-code :autodetect="language === ''" :code="code" -->
            <!-- :language="language"> -->
            <!-- </highlightjs> -->
            <highlightjs autodetect :code="code" id="codeBlock" ref="codeBlock" v-code />
        </div>
    </div>
</template>

<style scoped>
.hljs {
    border-radius: 10px;
    overflow: auto;
}
</style>
